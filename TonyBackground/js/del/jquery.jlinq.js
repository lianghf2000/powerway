//jQuery.extend({                
//		from:function(d) {
//				return new __jLINQQueryContainer(d);
//		};                
//});

jQuery.from = function(source,initalQuery) {
	
	var queryObject = function(d,q) {
		
	    //SETUP
	    //--------------------------------------------------
	    if(typeof(d) == "string") { 
	        d = $.data(d);
        };
        
	    //FIELDS
	    //--------------------------------------------------
	    //holds the query object
	    var self = this;
    	
	    //Holds the actual data being modified
	    var _data = d;
    									
	    //holds the current case state
	    var _usecase = true;
	    
	    //holds if strings should be trimmed
	    var _trim = false;
    									
	    //Holds the current query to run
	    var _query = q;
    	
	    //handling repeating commands
	    var _lastCommand = null;
	    var _lastField = null;                
	    var _negate = false;
	    var _queuedOperator = "";
	    var _sorting = new Array();
	    
	    	    
	    //ADDITIONAL SETUP
	    //--------------------------------------------------
	    //determine the array type. If the first element is an object
        //it assumes that properties will be used for queries. If not
        //the the fields themselves are compared
        var _useProperties = true;
        if(typeof(d) == "object" && d.push) {
            if (d.length > 0) {
                if(typeof(d[0]) != "object") { 
                    _useProperties = false;
                } else {
                    _useProperties = true;
                };
            };
        } else {
            throw "data provides is not an array";
        };
	    
    									
	    //EXPRESSIONS
	    //--------------------------------------------------
    	
	    //match strings with " " or ' '
	    var _exp_matchStrings = new RegExp("'[^']*'|\"[^\"]*\"", "gi");
    	
    	
	    //PRIVATE METHODS
	    //--------------------------------------------------
    	
	    //returns if there is data available or not
	    this._hasData = function() {
		    return _data == null ? false : _data.length == 0 ? false : true;
	    };
	    
	    //returns the string value the the type
	    this._getStr = function(s) {
	        var phrase = new Array();	        
	        if (_trim) { phrase.push("$.trim("); };
	        phrase.push(s+".toString()");
	        if (_trim) { phrase.push(")"); };
	        if (!_usecase) { phrase.push(".toLowerCase()"); };	        
	        return phrase.join("");
	    };
	    
        //Returns "toString()" if the value provided is a string        
        this._strComp = function(val) {
            if (typeof(val) == "string") {
                return ".toString()";
            } else {
                return "";
            };
        };
	        	
	    //returns a formatted object for group matching
	    this._group = function(f,u) {
		    return ({field:f.toString(),unique:u,items:new Array()});
	    };
    	
	    //(early version) - Converts value to a string
	    this._toStr = function(phrase) {	    
	        if (_trim) { phrase = $.trim(phrase); };
	        if (!_usecase) { phrase = phrase.toLowerCase(); };	    
		    phrase = phrase.toString().replace(new RegExp('\\"',"g"), '\\"');
		    return phrase;
	    };
    	
	    //Loops the data through a provided function
	    this._funcLoop = function(func) {
		    var results = new Array();
		    $.each(_data,function(i,v) { 
			    results.push(func(v)); 
		    }); 
		    return results;
	    };
    	
	    //Builds the queries by appending each part
	    this._append = function(s) {
    	
		    //appends operators when nothing has been
		    //defined, otherwise, starts the query string
		    if (_query == null) {
			    _query = "";
		    } else {
			    _query += _queuedOperator == "" ? " && " : _queuedOperator;
		    };
    		
		    //appends the string command and negates it if needed                        
		    if (_negate) { 
		        _query += "!"; 
            }; 
		    _query += "("+s+")";
    		
		    //reset the defaults
		    _negate = false;
		    _queuedOperator = "";
    	
	    };
    	    	
	    //Sets the current cached command
	    this._setCommand = function(f,c) { 
			    _lastCommand = f; 
			    _lastField = c; 
	    };
    	
	    //Resets the current state of negating queries
	    this._resetNegate = function() { 
			    _negate = false; 
	    };
    	
	    //Repeats the currently cached command (if any)
	    this._repeatCommand = function(f,v) { 
			    if (_lastCommand == null) { return self; };
			    if (f != null && v != null) { return _lastCommand(f,v); };                    
			    if (_lastField == null) { return _lastCommand(f); };
			    if (!_useProperties) { return _lastCommand(f); };
			    return _lastCommand(_lastField, f); 
	    };

	    //Compares two objects to dermine if they are equal or not                                    
	    this._equals = function(a,b) {
			    return (self._compare(a,b) == 0);
	    };
    	
	    //Compares two objects to dermine their sorting order
	    this._compare = function(a,b) {
			    if (a == null && b == null) { return 0; };
			    if (a == null && b != null) { return 1; };
			    if (a != null && b == null) { return -1; };
			    if(typeof(a) == "string") {
					    if (!_usecase) { 
							    a = a.toLowerCase();
							    b = b.toLowerCase();
					    };
					    if (a < b) { return -1; };
					    if (a > b) { return 1; };
					    return 0;
			    } else {
					    return a - b;
			    };
	    };
	    
	    //starts the effort to loop through sorting requests
	    this._performSort = function() {
	        if (_sorting.length == 0) { return; };
	        _data = self._doSort(_data,0);
	    };
	    
	    //performs the sort work on the specified queue
	    this._doSort = function(d,q) {	        
	        	        	        
	        //grab the values for this section
	        var by = _sorting[q].by;
	        var dir = _sorting[q].dir;	        
	        
	        //if at the end, just sort it
	        if (q == _sorting.length-1) {
	            return self._getOrder(d,by,dir);
	        };
	        
	        //increment forward to the next command
	        q++;
	        	        
	        //if this is not the last query, issue the next one for each group	        
	        var values = self._getGroup(d,by,dir);
	        var results = new Array();	        
	        
	        //sort and gather values - call _doSort again if 
	        //to check for futher commands
	        for(var i=0; i < values.length; i++) {	            
	            var sorted = self._doSort(values[i].items, q);	            
	            for(var j=0; j < sorted.length; j++) {
	                results.push(sorted[j]);
	            };
	        };
	        
	        //return the results for this section
	        return results;	        
	    };
	    
	    //performs the actual reordering of fields
	    this._getOrder = function(data,by,dir) {	        
		    var sortData = new Array();
		    $.each(data, function(i,v) { 
		        sortData.push(v); 
            });
	        sortData.sort(function(a,b) {
		        return self._compare(a[by],b[by]);
	        });
		    if (dir == "d" || dir == "dec" || dir == "decending") { 
		        sortData.reverse(); 
            };
		    return sortData;   
	    };
	    
	    //performs the grouping for the data provided
	    this._getGroup = function(data,by,dir) {
	        var results = new Array();
		    var group = null; var last = null;                        
		    $.each(self._getOrder(data,by,dir), function(i,v) {
			    if (!self._equals(last,v[by])) {
				    last = v[by];
				    if (group != null) { 
				        results.push(group);
                    };
				    group = self._group(by,v[by]);
			    };
			    group.items.push(v);
		    });
		    if (group != null) { 
		        results.push(group); 
            };
		    return results;
	    };
    	
	    //PUBLIC METHODS
	    //--------------------------------------------------
	    
	    //Tells a query to begin ignoring case       
	    this.ignoreCase = function() { 
	        _usecase = false; 
	        return self; 
        };
    	
	    //tells a query to start monitoring case
	    this.useCase = function() { 
	        _usecase = true; 
	        return self; 
        };
        
        //Tells a query to begin ignoring case       
	    this.trim = function() { 
	        _trim = true; 
	        return self; 
        };
    	
	    //tells a query to start monitoring case
	    this.noTrim = function() { 
	        _trim = false; 
	        return self; 
        };
    	
	    //Allows a query to combine constrains into a group
	    this.combine = function(f) {                        
		    var q = $.from(_data);
		    if (!_usecase) { q.ignoreCase(); };
		    if (_trim) { q.trim(); };
		    result = f(q).showQuery();
		    self._append(result);
		    return self;
	    };
    	
	    //Executes the current query and modifies the existing
	    //data, but returns the query object to allow further queries
	    this.execute = function() {
    			
		    //if no query, just cancel the execute   
		    var match = _query;
		    if (match == null) { return self; };
															
		    //now, do the actual query
		    results = new Array();
		    $.each(_data, function(i,rec) { 
				    if (eval(match)) { results.push(rec); };
		    });
			
		    //set the results and return the query object
		    _data = results;                            
		    return self;
    	
	    };
    	
	    //returns the current data for this query
	    //but does not run the query first
	    this.data = function() { return _data; };
    	
	    //Executes and selects the data for this query, allows
	    //for a function to be defined to refine the way the
	    //data is returned
	    this.select = function(f) { 
	        self._performSort();
            if (!self._hasData()) { return []; };
		    self.execute();        
		    if ($.isFunction(f)) { 
				    var results = new Array();
				    $.each(_data, function(i,v) {
					    results.push(f(v));
				    });
				    return results;
		    };
		    return _data;
	    };
	    
	    //Executes and selects the data for this query, allows
	    //for a function to be defined to refine the way the
	    //data is returned
	    this.hasMatch = function(f) {
            if (!self._hasData()) { return false; };
		    self.execute();        			    
		    return _data.length > 0;
	    };
    	
	    //Returns the string version of the current query
	    this.showQuery = function(cmd) { 
	        var queryString = _query;
			if (queryString == null) { queryString = "no query found"; }; 
	        if ($.isFunction(cmd)) {
	            cmd(queryString);
	            return self;
	        };	        
	        return queryString;
	    };
    							
	    //Repeats the last command with AND and NOT
	    this.andNot = function(f,v,x) { _negate = !_negate; return self.and(f,v,x); };                                    
    	
	    //Repeats the last command with OR and NOT
	    this.orNot = function(f,v,x) { _negate = !_negate; return self.or(f,v,x); };                  
    	
	    //Repeats the last command with NOT, also AND is implied
	    this.not = function(f,v,x) { return self.andNot(f,v,x); };
    	
	    //Repeats the last command with AND and uses the current negation state
	    this.and = function(f,v,x) { _queuedOperator = " && "; if (f == null) { return self; }; return self._repeatCommand(f,v,x); };                    
    	
	    //Repeats the last command with OR and uses the current negation state
	    this.or = function(f,v,x) { _queuedOperator = " || "; if (f == null) { return self; }; return self._repeatCommand(f,v,x); };   
    	
	    //Compares boolean fields using NOT
	    this.isNot = function(f) { _negate = !_negate; return self.is(f); };                
    	
	    //Compares boolean fields
	    this.is = function(f) { self._append('rec.'+f); self._resetNegate(); return self; };

        //Selects string fields that start with the specified string             
	    this._compareValues = function(func,f,v,how) {
	    
	        //change how the field is referenced
	        var fld;
	        if (_useProperties) {
		        fld = 'rec.'+f;
	        } else {
	            fld = 'rec';
	        };
	        
	        //change the type of equating
	        var val = v == null ? f : v;
	        if (typeof(val) == "string") {
	            fld = self._getStr(fld);
	            val = self._getStr('"'+self._toStr(val)+'"');
	        } else if(val.getDate) {
	            fld = fld+'.toUTCString()';
	            val = '(new Date("'+val.toUTCString()+'").toUTCString())';
	        } else {
	            val = val.toString();
	        };
	    
	        //append the query after formatting
            self._append(fld+' '+how+' '+val);
		    self._setCommand(func, f); 
		    self._resetNegate();
		    return self;
	    };
	    
	    
	    //Shortcut for ==
	    this.equals = function(f,v) {
	        return self._compareValues(self.equals,f,v,"==");
	    };
	    
	    //Shortcut for >
	    this.greater = function(f,v) {
	        return self._compareValues(self.greater,f,v,">");
	    };
	    
	    //Shortcut for <
	    this.less = function(f,v) {
	        return self._compareValues(self.less,f,v,"<");
	    };
	    
	    //Shortcut for >=
	    this.greaterOrEquals = function(f,v) {
	        return self._compareValues(self.greaterOrEquals,f,v,">=");
	    };
	    
	    //Shortcut for <=
	    this.lessOrEquals = function(f,v) {
	        return self._compareValues(self.lessOrEquals,f,v,"<=");
	    };
	    
	    //shortcut for rec > n && rec < n
	    this.between = function(f,v1,v2) {
	        var val1 = v2 == null ? f : v1;
	        var val2 = v2 == null ? v1 : v2;	    	        
	        f = v2 == null ? _lastField : f;
	        self.combine(function(q) {	
	            return q.greater(f,val1,false).less(f,val2,false);
	        });
		    self._setCommand(self.between, f); 
		    self._resetNegate();
		    return self;
	    };
	    
	    //shortcut for rec >= n && rec <= n
	    this.betweenOrEquals = function(f,v1,v2) {
	        var val1 = v2 == null ? f : v1;
	        var val2 = v2 == null ? v1 : v2;	    	        
	        f = v2 == null ? _lastField : f;
	        self.combine(function(q) {	
	            return q.greaterOrEquals(f,val1,false).lessOrEquals(f,val2,false);
	        });
		    self._setCommand(self.betweenOrEquals, f); 
		    self._resetNegate();
		    return self; 
	    };

	    //Selects string fields that start with the specified string             
	    this.startsWith = function(f,v) {
	        var val = v == null ? f : v;
	        var length = _trim ? $.trim(val.toString()).length : val.toString().length;
	        if (_useProperties) {
		        self._append(self._getStr('rec.'+f)+'.substr(0,'+length+') == '+self._getStr('"'+self._toStr(v)+'"'));
	        } else {
	            var length = _trim ? $.trim(v.toString()).length : v.toString().length;
	            self._append(self._getStr('rec')+'.substr(0,'+length+') == '+self._getStr('"'+self._toStr(f)+'"'));	            
	        };
		    self._setCommand(self.startsWith, f); 
		    self._resetNegate();
		    return self;
	    };
    	
	    //Selects fields that end with the specified string
	    this.endsWith = function(f,v) {
            var val = v == null ? f : v;
            var length = _trim ? $.trim(val.toString()).length : val.toString().length;
            if (_useProperties) {
	            self._append(self._getStr('rec.'+f)+'.substr('+self._getStr('rec.'+f)+'.length-'+length+','+length+') == "'+self._toStr(v)+'"');
            } else {
                self._append(self._getStr('rec')+'.substr('+self._getStr('rec')+'.length-"'+self._toStr(f)+'".length,"'+self._toStr(f)+'".length) == "'+self._toStr(f)+'"');                
            };                  
		    self._setCommand(self.endsWith, f); 
		    self._resetNegate();
		    return self;
	    };
    	
	    //Selects fields that contain the specified string
	    this.contains = function(f,v) {
	        if (_useProperties) {
	            self._append(self._getStr('rec.'+f)+'.indexOf("'+self._toStr(v)+'",0) > -1');
            } else {
                self._append(self._getStr('rec')+'.indexOf("'+self._toStr(f)+'",0) > -1');
            };                 
		    self._setCommand(self.contains, f); 
		    self._resetNegate();
		    return self;
	    };
    	
	    //Selects fields that match the comparisons in the command
	    //Fields being matched must start with a .<FieldName> to 
	    //identify them when running the query
	    this.where = function(cmd) {
	    
	        //if it is a command we need to execute anything
	        //currently set, otherwise, the new query object
	        //will not have the new query
	        if ($.isFunction(cmd)) {
	            self.execute();
	            var results = new Array();	            
	            $.each(_data, function(i,v) {
	                if (cmd(v)) { results.push(v); };
	            });
	            return $.from(results,self.showQuery());
	        };
	        
	        //otherwise, just add the commands
		    self._append(cmd);
		    self._setCommand(this.where, null); 
		    self._resetNegate();
		    return self;     
		                   
	    };
    	
	    //skips the specified number of records and returns
	    //the rest (if any)
	    this.skip = function(count) {     
		    if (!self._hasData()) { return self; };  
		    if (count > _data.length) { return []; };
		    var results = new Array();
		    for(var i=count;i<_data.length;i++) {
			    results.push(_data[i]);
		    };
		    return $.from(results);
	    };
    	
	    //Takes as many records as are specified but will
	    //not cause errors if it takes too many
	    this.take = function(count) {
		    if (!self._hasData()) { return self; };  
		    if (count > _data.length) { return $.from(_data); };
		    var results = new Array();
		    for(var i=0;i<count;i++) {
			    results.push(_data[i]);
		    };
		    return $.from(results);
	    };
    	
	    //Returns the sum of the specified field
	    this.sum = function(q) {
    		
		    //if there is no data, return itself because it won't mater         
		    if (!self._hasData()) { return self; };
		    if (q == null || q == "") { return self; };

		    //if manually controlled
		    if ($.isFunction(q)) {
			    var total = 0;
			    $.each(_data, function(i,v) { 
				    total += q(v); 
			    });
			    return total;
		    };

		    //if targeting a field                        
		    var total = 0;
		    try {                                                                                
		        $.each(_data, function(i,v) { 
				    total += v[q]; 
		        });
			    return total;
		    } catch(ex) {
			    return 0;
		    };
	    };
    	
	    //Gets the distinct values for the specified field
	    //and returns them as an array of _group objects
	    this.groupBy = function(by, dir) {
		    if (!self._hasData()) { 
		        return null; 
            };
		    return self._getGroup(_data,by,dir);
	    };
    	
	    //Returns the first element in the data or if nothing
	    //is available, returns null
	    this.first = function() {
		    if (!self._hasData()) { 
		        return null; 
            };
		    return _data[0];
	    };
    	
	    //Returns the last element in the data or if nothing
	    //is available, returns null
	    this.last = function() {
		    if (!self._hasData()) { 
		        return null; 
            };
		    return _data[_data.length-1];
	    };
    	
	    //Returns an array of the distinct values for the specified field
	    this.distinct = function(by,dir) {
		    var groups = self.groupBy(by,dir);
		    var results = new Array();
		    $.each(groups, function(i,v) { 
		        results.push(v.unique); 
            });
		    return results;
	    };
    	
	    //Queues sorting for the next called select statement
	    this.orderBy = function(by,dir) {	    
	        dir = dir == null ? "a" : $.trim(dir.toString().toLowerCase());
	        if (dir == "dec" || dir == "decending") { dir = "d"; };
	        if (dir == "asc" || dir == "ascending") { dir = "a"; };
	        _sorting.push({by:by,dir:dir});
		    return self;
	    };
    	
	    //returns all values that do not have a match in the second array
	    this.except = function(col,f) {
		    if (!$.isFunction(f)) { 
		        f = self._equals; 
            };
		    var nomatch = new Array();
		    $.each(_data, function(i,v) {
			    var isMatch = false;
			    $.each(col, function(j,w) {                      
				    if (!isMatch && f(v,w)) { isMatch = true; };
			    });
			    if (!isMatch) { nomatch.push(v); };
		    });
		    return nomatch;
	    };  
    	
	    //Returns all values that are found in both arrays
	    this.intersect = function(col,f) {
		    if (!$.isFunction(f)) { f = self._equals; };
		    var matches = new Array();
		    $.each(_data, function(i,v) {
			    var isMatch = false;
			    $.each(col, function(j,w) {                            
				    if (!isMatch && f(v,w)) { isMatch = true; };
			    });
			    if (isMatch) { 
			        matches.push(v); 
                };
		    });
		    return matches;
	    };
    									
	    //return the query object itself
	    return self;

    };
    
    //return the new query object
    return new queryObject(source,null);

};
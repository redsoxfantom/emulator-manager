/**
* Gamedata.js
*
* @description :: TODO: You might write a short summary of how this model works and what it represents here.
* @docs        :: http://sailsjs.org/#!documentation/models
*/

module.exports = {

  attributes: {
	NameSystem : {
		type: "string",
		required : true,
		unique : true
	},
	Name : {
		type : "string",
		required : false
	},
	Publisher : {
		type : "string",
		required : false
	},
	System : {
		type : "string",
		required : false
	},
	Image : {
		type : "string",
		required : false
	}
  }
};


/**
 * GamedataController
 *
 * @description :: Server-side logic for managing gamedatas
 * @help        :: See http://sailsjs.org/#!/documentation/concepts/Controllers
 */

module.exports = {
	GetGameDataByNameSystem:function(req,res) {
		var id = req.param('id');
		Gamedata.findOne({NameSystem:id})
			.exec(function(err,user) {
				if(err) {
					return res.json({
						error:err
					});
				}
				if(user === undefined) {
					return res.notFound();
				}
				else{
					return res.json({
						notFound:false,
						userData:user
					});
				}
			});
	}
};


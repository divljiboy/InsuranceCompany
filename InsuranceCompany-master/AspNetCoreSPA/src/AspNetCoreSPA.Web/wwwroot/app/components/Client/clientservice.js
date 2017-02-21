(function () {

    angular.module('app')
    .service('ClientService', ['$http', function ($http) {
            //metode servisa
            return {
                getAll: function () {

                   $http.get("api/Client")
                   .then(function (response) {
                    return response;
                });
               },
               getId:function(id){
               return  $http.get("api/Client/"+id)
                
            }

            ,
            put: function (client)
            {
               return  $http.put("api/Client/"+client.id, client)


            },
            post: function (client) {
               $http.post("api/Client", client).then(function(resp){
                return resp.data;
               });
           },
              delete : function(client)
               {
                $http.delete("api/Client/"+client.id).then(function(response){
                    return response;
                });


              }
          }




      }]);

})();
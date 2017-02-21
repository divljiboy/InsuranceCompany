(function () {

  angular.module('app')
  .service('PolicyService', ['$http', function ($http) {
            //metode servisa
            return {
              getAll: function () {

               return $http.get("api/Policy")

             },
             getId:function(id){
              return $http.get("api/Policy/"+id)

            }

            ,
            put: function (policy)
            {
             return  $http.put("api/Policy/"+policy.id, policy)


           },
           post: function (finalPolicy2,ClientNavigation2,clientCar2,finalCar2,clientHouse2,finalHouse2,finalDestination2)
           {
            var req = {
              method: 'POST',
              url: '/api/Policy/',
              headers: {
                'Content-Type': 'application/json;charset=utf-8'
              },
              data: JSON.stringify({finalPolicy:finalPolicy2,ClientNavigation:ClientNavigation2,clientCar:clientCar2,finalCar:finalCar2,clientHouse:clientHouse2,finalHouse:finalHouse2,finalDestination:finalDestination2})

            }
            return $http(req);
          },
          delete : function(policy)
          {
            return $http.delete("api/Policy/"+policy.id)


          }
        }




      }]);

})();











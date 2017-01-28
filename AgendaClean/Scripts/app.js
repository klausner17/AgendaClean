//define aplicação angular e o controller
var app = angular.module("agendaApp", []);

//controller dos contatos
app.controller("contactsController", function ($scope, $http) {
    $http.get('/api/Contactapi/getbyuserid/ec5b8058-e848-46a9-b60e-3bff26c8e90d')
    .success(function (result) {
        $scope.contacts = result;
    })
    .error(function (data) {
        console.log(data);
    });
});

//metodo add contato
$scope.AddContact = function (contact) {
    $http.post('api/contact/Add/', { newContact: contact })
    .success(function (result) {
        $scope.contacts = result;
        delete $scope.contactAdd;
    })
    .error(function (data) {
        console.log(data);
    });
}
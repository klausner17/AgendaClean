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

    //metodo add contato
    $scope.AddContact = function (contact) {
        contact.userId = 'ec5b8058-e848-46a9-b60e-3bff26c8e90d';
        $http.put('/api/contactapi/add', contact )
        .success(function (result) {
            $scope.contacts = result;
            delete $scope.contactAdd;
        })
        .error(function (data) {
            console.log(data);
        });
    }

    //metodo para remover contato
    $scope.DeleteContact = function ( contact ) {
        $http.put('/api/contactapi/delete', contact)
        .success(function (result) {
            $scope.contacts = result;
        })
        .error(function (data) {
            console.log(data);
        });
    }

    //metodo para remover contato
    $scope.DeleteContact = function (contact) {
        $http.put('/api/contactapi/delete', contact)
        .success(function (result) {
            $scope.contacts = result;
        })
        .error(function (data) {
            console.log(data);
        });
    }

    $scope.InitEdit = function (contact) {
        $scope.contactEdit.Name = contact.Name;
        $scope.contactEdit.Phone = contact.Phone;
        $scope.contactEdit.Birthdate = contact.Birthdate;
        $scope.contactEdit.Email = contact.Email;
        $scope.contactEdit.Address = contact.Address;
        console.log("o caminhão de laranja passou por aqui? - Passou!" + contact.Name);
    }

    //metodo para editar contato
    $scope.EditContact = function (contact) {
        $http.put('/api/contactapi/edit', contact)
        .success(function (result) {
            $scope.contacts = result;
        })
        .error(function (data) {
            console.log(data);
        });
    }
});

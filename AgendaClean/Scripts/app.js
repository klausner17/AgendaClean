//define aplicação angular e o controller
var app = angular.module("agendaApp", []);

//controller dos contatos
app.controller("contactsController", function ($scope, $http) {

    $scope.init = function (id) {
        $scope.UserId = id;
        $scope.contactAdd = {
            Name: "",
            Birthdate: "",
            Address: "",
            Email: "",
            Phone: ""
        };
        $scope.contactEdit = {
            Name: "",
            Birthdate: "",
            Address: "",
            Email: "",
            Phone: ""
        };
        $scope.getContacts();
    }

    
    $scope.getContacts = function () {
        $http.get('/api/Contactapi/getbyuserid/' + $scope.UserId )
        .success(function (result) {
            $scope.contacts = result;
        });
    }

    //metodo add contato
    $scope.AddContact = function (contact) {
        contact.UserId = $scope.UserId;
        $http.post('/api/contactapi/add', contact )
        .success(function (result) {
            $('#modalNewContact').modal('hide');
            $scope.getContacts();
            delete $scope.contactAdd;
        })
        .error(function (data) {
            console.log(data);
        });
    }

    //metodo para remover contato
    $scope.DeleteContact = function ( id ) {
        $http.delete('/api/contactapi/delete/' + id)
        .success(function (result) {
            $scope.getContacts();
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
        $scope.contactEdit.Id = contact.Id;
        $scope.contactEdit.UserId = contact.UserId;
    }

    //metodo para editar contato
    $scope.EditContact = function (contact) {
        $http.put('/api/contactapi/edit', contact)
        .success(function (result) {
            $('#modalEditContact').modal('hide');
            $scope.getContacts();
            delete $scope.contactEdit;
        })
        .error(function (data) {
            console.log(data);
        });
    }
});

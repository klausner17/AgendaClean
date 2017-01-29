//define aplicação angular e o controller
var app = angular.module("agendaApp", []);

//controller dos contatos
app.controller("contactsController", function ($scope, $http) {

    $http.get('/api/Contactapi/getbyuserid/' + $scope.UserId)
    .success(function (result) {
        $scope.contacts = result;
        $scope.contactAdd = {};
        $scope.contactEdit = {};
    })
    .error(function (data) {
        console.log(data);
    });

    //metodo add contato
    $scope.AddContact = function (contact, userId) {
        contact.UserId = userId;
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
            $scope.contacts = result;
        })
        .error(function (data) {
            console.log(data);
        });
    }
});

app.controller("loginController", function ($scope, $http) {

    $scope.Login = function (user) {
        $http.get('/api/userapi/VerifyUser/' + user.Login )
        .success(function (result) {
            $scope.statusVerify = result;
            if (result == 'true') {
                $http.post('/Token', { username: user.Login, password: user.Password })
                .success(function (result) {
                    
                })
            }
            console.log(result);
        })
        .error(function (data) {
            console.log(data);
        });
    }
});
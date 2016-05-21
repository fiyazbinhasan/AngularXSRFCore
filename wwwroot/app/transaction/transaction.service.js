(function () {
    'use strict';

    angular
        .module('app')
        .service('TransactionService', TransactionService);

    TransactionService.$inject = ['$http'];

    function TransactionService($http) {
        this.getTransactions = getTransactions;
        this.addTransaction = addTransaction;

        function getTransactions() {
            return $http({
                method: 'GET',
                url: '/api/transaction'
            });
        }

        function addTransaction(transaction) {
            return $http({
                method: 'POST',
                url: '/api/transaction',
                data: transaction
            });
        }
    }
})();
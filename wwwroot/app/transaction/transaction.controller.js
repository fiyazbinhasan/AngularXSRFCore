(function () {
    'use strict';

    angular
        .module('app')
        .controller('TransactionController', TransactionController);

    TransactionController.$inject = ['TransactionService'];

    function TransactionController(TransactionService) {
        /* jshint validthis:true */
        var vm = this;

        vm.transactions = [];
        vm.transactionAmount = undefined;

        vm.getTransactions = getTransactions;
        vm.debit = debit;
        vm.credit = credit;

        function getTransactions() {
            TransactionService.getTransactions().success(function (response) {
                vm.transactions = response;
            });
        }

        function debit() {
            var transaction = {
                transactionAmount: vm.transactionAmount,
                transactionType: 'DEBIT'
            }

            TransactionService.addTransaction(transaction).success(function (response) {
                vm.getTransactions();
            });
        }

        function credit() {
            var transaction = {
                transactionAmount: vm.transactionAmount,
                transactionType: 'CREDIT'
            }

            TransactionService.addTransaction(transaction).success(function (response) {
                vm.getTransactions();
            });
        }

        activate();

        function activate() {
            vm.getTransactions();
        }
    }
})();

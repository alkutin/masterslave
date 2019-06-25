$(document).ready(function () {
    $.signalR.masterSlaveHub.on('slaveCodeRegistered', function (data) {
        console.log('slaveCodeRegistered', data);
    });

    $.signalR.hub.start(function () {
        $.signalR.masterSlaveHub.server.registerSlave();
    });
});

var slaveCommands = {
    OpenThisUrl: function (slave, url, mode) {
        $.signalR.masterSlaveHub.server.openThisUrl(slave, url, mode);
    }
};

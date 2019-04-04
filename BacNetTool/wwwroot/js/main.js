var BACNet;
(function (BACNet) {
    var Main = /** @class */ (function () {
        function Main($scope) {
            var _this = this;
            this.$scope = $scope;
            this.mode = Mode.view;
            this.navTree = [];
            this.setSelected = function (select) {
                _this.selected = select;
            };
            this.isEditMode = function () {
                return _this.mode === Mode.edit;
            };
            this.toggleEdit = function () {
                if (_this.isEditMode())
                    _this.mode = Mode.view;
                else
                    _this.mode = Mode.edit;
            };
            this.submit = function (item) {
            };
            this.isNae = function (nav) {
                return nav.deviceType === DeviceType.Nae;
            };
            $scope["d"] = this;
            this.init();
        }
        Main.prototype.init = function () {
            var me = this;
            var nav = $('#tree').tree({
                uiLibrary: 'bootstrap',
                dataSource: '/Home/GetNav',
                primaryKey: 'id',
                textField: 'objectName',
                childrenField: 'inverseObjectTypeNavigation',
                select: function (a, b, c) {
                    me.setSelected(me.navTree.filter(function (n) { return n.id == c; })[0]);
                    me.$scope.$apply();
                }
            });
            nav.on('dataBound', function () {
                me.navTree = nav.getAll();
            });
        };
        return Main;
    }());
    BACNet.Main = Main;
    var DeviceType;
    (function (DeviceType) {
        DeviceType[DeviceType["Nae"] = 0] = "Nae";
        DeviceType[DeviceType["Other"] = 1] = "Other";
    })(DeviceType || (DeviceType = {}));
    var Mode;
    (function (Mode) {
        Mode[Mode["view"] = 0] = "view";
        Mode[Mode["edit"] = 1] = "edit";
    })(Mode || (Mode = {}));
    var app = angular.module("main-app", []);
    app.controller("Main", Main);
})(BACNet || (BACNet = {}));
//# sourceMappingURL=main.js.map
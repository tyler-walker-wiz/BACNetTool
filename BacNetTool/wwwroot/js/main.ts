namespace BACNet {
    export class Main {
        selected: Nav;
        mode = Mode.view;
        navTree: Nav[] = [];
        editForm: ng.IFormController;
        constructor(private $scope: ng.IScope, private $http: ng.IHttpService) {
            $scope["d"] = this;
            this.init();
        }
        init() {
            var me = this;
            let nav = $('#tree').tree({
                uiLibrary: 'bootstrap',
                dataSource: '/Home/GetNav',
                primaryKey: 'id',
                textField: 'objectName',
                childrenField: 'inverseObjectTypeNavigation',
                select: (a, b, c: string) => {
                    me.setSelected(me.navTree.filter(n => n.id == c)[0]);
                    me.$scope.$apply();
                }
            });
            nav.on('dataBound', () => {
                me.navTree = nav.getAll();
            });
        }
        setSelected = (select: Nav) => {
            this.selected = select;
        }
        isEditMode = () => {
            return this.mode === Mode.edit;
        }
        toggleEdit = () => {
            if (this.isEditMode())
                this.mode = Mode.view
            else this.mode = Mode.edit;
        }
        submit = (item: Nav) => {

        }
        isNae = (nav: Nav) => {
            return nav.deviceType === DeviceType.Nae;
        }

        submitChanges = () => {
            let data = {
                vendorName: this.editForm.vendorName.$modelValue,
                objectName: this.editForm.objectName.$modelValue,
                id: this.selected.id
            }
            let request = this.$http({
                method: 'post',
                url: '/Home/SubmitDevice',
                data: $.param(data),
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },

            }).then((p) => alert("Submitted!"));
            request.catch((r) => alert(r));
            this.editForm.$setPristine();
        }
    }
    interface IPropPage {

    }
    interface Nav {
        id: string;
        name: string;
        ipaddress?: string;
        deviceType?: DeviceType;
        children?: Nav[];
    }

    enum DeviceType {
        Nae, Other
    }

    enum Mode {
        view,
        edit
    }

    let app = angular.module("main-app", []);
    app.controller("Main", Main);
}
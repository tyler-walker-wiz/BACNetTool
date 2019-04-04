namespace BACNet {
    export class Main {
        selected: Nav;
        mode = Mode.view;
        navTree: Nav[] = [];
        constructor(private $scope: ng.IScope) {
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
                    me.setSelected(me.navTree.filter(n=>n.id == c)[0]);
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
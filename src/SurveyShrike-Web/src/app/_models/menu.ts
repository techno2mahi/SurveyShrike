export interface Menu {
    systemName: string;
    title: string;
    url: string;
    type: string;
    icon: string;
    permissions: string;
    childNodes?: Menu[];
    selected: boolean;
    isHidden: boolean;
}

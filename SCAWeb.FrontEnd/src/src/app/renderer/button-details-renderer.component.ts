import { Component } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';

@Component({
    selector: 'app-button-details-renderer',
    template: `
    <button type="button" class="btn btn-secondary btn-sm" (click)="onClick($event)"><i class="fa fa-search"></i></button>
    `
})

export class ButtonDetailsRendererComponent implements ICellRendererAngularComp {

    params;
    label: string;

    agInit(params): void {
        this.params = params;
        this.label = this.params.label || null;
    }

    refresh(params?: any): boolean {
        return true;
    }

    onClick($event) {
        if (this.params.onClick instanceof Function) {
            // put anything into params u want pass into parents component
            const params = {
                event: $event,
                rowData: this.params.node.data
                // ...something
            }
            this.params.onClick(params);

        }
    }
}
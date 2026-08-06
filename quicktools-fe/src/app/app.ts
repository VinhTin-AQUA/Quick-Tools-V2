import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ButtonModule } from '@openng/optimus-ui/button';
import { WebuiService } from './webui-service';

@Component({
    selector: 'app-root',
    imports: [RouterOutlet, ButtonModule],
    templateUrl: './app.html',
    styleUrl: './app.css',
})
export class App {
    protected readonly title = signal('quicktools-fe');

    constructor(private webuiService: WebuiService) {}

    async longTask() {
        const r = await this.webuiService.call<string>('longTask', 2);
        console.log(r);
    }

    async getData() {
        const r = await this.webuiService.call<any>('getData');
        console.log(r);
    }

    async sendData() {
        const r = await this.webuiService.callJson<string>('sendData', {
            name: 'Pootin',
            age: 10,
        });
        console.log(r);
    }

    async asyncFunction() {
        const r = await this.webuiService.call<string>('asyncFunction');
        console.log(r);
    }
}

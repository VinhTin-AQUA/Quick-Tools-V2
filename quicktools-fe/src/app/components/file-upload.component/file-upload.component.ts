import { Component, input, model, output } from '@angular/core';
import { ButtonModule } from '@openng/optimus-ui/button';

@Component({
    selector: 'file-upload-component',
    imports: [ButtonModule],
    templateUrl: './file-upload.component.html',
    styleUrl: './file-upload.component.css',
})
export class FileUploadComponent {
    closePopup = output<void>();
    files = model<File[]>([]);


    // Khi muốn đóng popup
    onUploadCompleted() {
        this.closePopup.emit();
    }

}

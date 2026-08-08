import { Component, input, model, output } from '@angular/core';
import { ButtonModule } from '@openng/optimus-ui/button';
import { FileSelectEvent, FileUploadModule } from '@openng/optimus-ui/fileupload';
import { TagModule } from '@openng/optimus-ui/tag';
import { FileSizePipe } from '../../pipes/file-size-pipe';

@Component({
    selector: 'file-upload-component',
    imports: [ButtonModule, FileUploadModule, TagModule, FileSizePipe],
    templateUrl: './file-upload.component.html',
    styleUrl: './file-upload.component.css',
})
export class FileUploadComponent {
    closePopup = output<void>();
    files = model<File[]>([]);

    // Khi muốn đóng popup
    onClosePopup() {
        this.files.set([]);
        this.closePopup.emit();
    }

    onSelectFile(event: FileSelectEvent) {
        const fileList = event.currentFiles || [];
        const filesArray = Array.isArray(fileList) ? fileList : [];
        this.files.set(filesArray);

        // filesArray.forEach((file, index) => {
        //     console.log(`File ${index + 1}: ${file.name} (${file.size} bytes)`);
        // });

    }
}

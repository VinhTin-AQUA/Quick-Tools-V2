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
    files = model<File[]>([]);
    isDragging = false;

    onSelectFile(event: FileSelectEvent) {
        const fileList = event.currentFiles || [];
        const filesArray = Array.isArray(fileList) ? fileList : [];
        this.files.set(filesArray);

        // filesArray.forEach((file, index) => {
        //     console.log(`File ${index + 1}: ${file.name} (${file.size} bytes)`);
        // });
    }

    // Khi file được kéo vào vùng upload
    onDragOver(event: DragEvent) {
        event.preventDefault();
        event.stopPropagation();

        this.isDragging = true;
    }

    // Khi file rời khỏi vùng upload
    onDragLeave(event: DragEvent) {
        event.preventDefault();
        event.stopPropagation();

        this.isDragging = false;
    }

    // Khi thả file
    onDrop(event: DragEvent) {
        event.preventDefault();
        event.stopPropagation();

        this.isDragging = false;

        const fileList = event.dataTransfer?.files;

        if (!fileList || fileList.length === 0) {
            return;
        }

        const filesArray = Array.from(fileList).filter((file) => file.type.startsWith('image/'));

        this.files.set(filesArray);
    }
}

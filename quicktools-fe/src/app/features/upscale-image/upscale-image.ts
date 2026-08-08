import { Component, computed, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FileModel } from '../../models/file.model';
import { SelectModule } from '@openng/optimus-ui/select';
import { ButtonModule } from '@openng/optimus-ui/button';
import { FileUploadEvent, FileUploadModule } from '@openng/optimus-ui/fileupload';
import { BadgeModule } from '@openng/optimus-ui/badge';
import { ProgressBarModule } from '@openng/optimus-ui/progressbar';
import { FileUploadComponent } from '../../components/file-upload.component/file-upload.component';

import { FileSizePipe } from '../../pipes/file-size-pipe';

@Component({
    selector: 'app-upscale-image',
    imports: [
        FormsModule,
        SelectModule,
        ButtonModule,
        FileUploadModule,
        BadgeModule,
        ButtonModule,
        FileUploadModule,
        ProgressBarModule,
        FileUploadComponent,
        FileSizePipe,
    ],
    templateUrl: './upscale-image.html',
    styleUrl: './upscale-image.css',
})
export class UpscaleImage {
    selectedOption: string = '1';
    sizeMultiplierOptions = ['1', '2'];

    uploadedFiles = signal<FileModel[]>([]);
    totalSize = computed(() => {
        return this.uploadedFiles().reduce((sum, file) => sum + file.file.size, 0);
    });

    selectedImage: FileModel | null = null;
    showPopupImagePreview: boolean = false;

    processedImages = signal<FileModel[]>([]);
    progress: number = 0;
    isUploading: boolean = false;

    onImageClick(image: FileModel): void {
        this.selectedImage = image;
        this.showPopupImagePreview = true;
    }

    closePopupImagePreview(): void {
        this.showPopupImagePreview = false;
        this.selectedImage = null;
    }

    removeImage(event: MouseEvent, id: string) {
        event.preventDefault();
        event.stopPropagation();
        this.uploadedFiles.update((currentFiles) => currentFiles.filter((f) => f.id !== id));
    }

    onSubmit(): void {
        console.log('Submitting images:', this.uploadedFiles().length);
    }

    onClear(): void {
        this.progress = 0;
        this.uploadedFiles.set([]);
    }

    toggleSelect(image: FileModel): void {
        image.selected = !image.selected;
    }

    ngOnDestroy() {
        for (let prev of this.uploadedFiles()) {
            URL.revokeObjectURL(prev.previewUrl);
        }
        this.onClear();
    }
}

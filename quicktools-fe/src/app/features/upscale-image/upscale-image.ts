import { Component, computed, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ImageItem } from './models';
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

    uploadedFiles = signal<File[]>([]);
    totalSize = computed(() => {
        return this.uploadedFiles().reduce((sum, file) => sum + file.size, 0);
    });

    previewImages = computed(() => {
        const images = this.uploadedFiles().map((file) => {
            const image: ImageItem = {
                id: crypto.randomUUID().toString(),
                name: file.name,
                previewUrl: URL.createObjectURL(file),
                size: file.size,
            };
            return image;
        });
        return images;
    });
    selectedImage: ImageItem | null = null;
    showPopupImagePreview: boolean = false;
    processedImages = signal<ImageItem[]>([]);

    progress: number = 0;
    isUploading: boolean = false;

    onImageClick(image: ImageItem): void {
        this.selectedImage = image;
        this.showPopupImagePreview = true;
    }

    closePopupImagePreview(): void {
        this.showPopupImagePreview = false;
        this.selectedImage = null;
    }

    onClear(): void {
        this.progress = 0;
        this.uploadedFiles.set([]);
    }

    onSubmit(): void {
        console.log('Submitting images:', this.uploadedFiles().length);
    }

    toggleSelect(image: ImageItem): void {
        image.selected = !image.selected;
    }
}

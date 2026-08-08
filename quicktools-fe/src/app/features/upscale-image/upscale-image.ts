import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ImageItem } from './models';
import { SelectModule } from '@openng/optimus-ui/select';
import { ButtonModule } from '@openng/optimus-ui/button';
import { FileUploadEvent, FileUploadModule } from '@openng/optimus-ui/fileupload';

import { BadgeModule } from '@openng/optimus-ui/badge';
import { ProgressBarModule } from '@openng/optimus-ui/progressbar';
import { FileUploadComponent } from '../../components/file-upload.component/file-upload.component';

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
    ],
    templateUrl: './upscale-image.html',
    styleUrl: './upscale-image.css',
})
export class UpscaleImage {
    selectedOption: string = '1';
    sizeMultiplierOptions = ['1', '2'];

    images: ImageItem[] = [];
    selectedImage: ImageItem | null = null;
    showPopupImagePreview: boolean = false;

    uploadedFiles: File[] = [];
    totalSize: number = 0;
    showPopupChooseFiles: boolean = false;

    progress: number = 0;
    isUploading: boolean = false;

    get processedImages(): ImageItem[] {
        return this.images.map((img) => ({
            ...img,
            selected: img.selected || false,
        }));
    }

    formatFileSize(bytes: number): string {
        if (bytes === 0) return '0 B';
        const k = 1024;
        const sizes = ['B', 'KB', 'MB', 'GB'];
        const i = Math.floor(Math.log(bytes) / Math.log(k));
        const size = bytes / Math.pow(k, i);

        if (i === 0) return `${size} ${sizes[i]}`;
        if (i === 1) return `${Math.round(size)} ${sizes[i]}`;
        return `${size.toFixed(1)} ${sizes[i]}`;
    }

    onImageClick(image: ImageItem): void {
        this.selectedImage = image;
        this.showPopupImagePreview = true;
    }

    closePopup(): void {
        this.showPopupImagePreview = false;
        this.selectedImage = null;
    }

    onClear(): void {
        this.images = [];
        this.progress = 0;
    }

    onSubmit(): void {
        const selectedImages = this.images.filter((img) => img.selected);
        console.log('Submitting images:', selectedImages);
    }

    toggleSelect(image: ImageItem): void {
        image.selected = !image.selected;
    }

    /* upload file */
    onShowPopupChooseFiles(flag: boolean = true) {
        this.showPopupChooseFiles = flag;
    }
}

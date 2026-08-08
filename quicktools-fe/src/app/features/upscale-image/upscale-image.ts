import { Component, inject } from '@angular/core';
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


    onShowPopupChooseFiles(flag: boolean = true) {
        this.showPopupChooseFiles = flag;
    }



    onImageClick(image: ImageItem): void {
        this.selectedImage = image;
        this.showPopupImagePreview = true;
    }

    closePopupImagePreview(): void {
        this.showPopupImagePreview = false;
        this.selectedImage = null;
    }

    onClear(): void {
        this.images = [];
        this.progress = 0;
    }

    onSubmit(): void {
        console.log('Submitting images:', this.uploadedFiles.length);
    }

    toggleSelect(image: ImageItem): void {
        image.selected = !image.selected;
    }


}

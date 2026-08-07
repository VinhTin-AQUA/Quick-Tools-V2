import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ImageItem } from './models';
import { SelectModule } from '@openng/optimus-ui/select';
import { ButtonModule } from '@openng/optimus-ui/button';

@Component({
    selector: 'app-upscale-image',
    imports: [FormsModule, SelectModule, ButtonModule],
    templateUrl: './upscale-image.html',
    styleUrl: './upscale-image.css',
})
export class UpscaleImage {
    selectedOption: string = '1';
    progress: number = 0;
    isUploading: boolean = false;
    selectedImage: ImageItem | null = null;
    showPopup: boolean = false;

    // Mock data for demonstration
    images: ImageItem[] = [
        {
            id: 1,
            name: 'nature-photo-1.jpg',
            size: 245760, // 240KB
            url: 'https://picsum.photos/seed/1/800/600',
            thumbnail: 'https://picsum.photos/seed/1/100/100',
        },
        {
            id: 2,
            name: 'city-view-2.png',
            size: 1572864, // 1.5MB
            url: 'https://picsum.photos/seed/2/800/600',
            thumbnail: 'https://picsum.photos/seed/2/100/100',
        },
        {
            id: 3,
            name: 'mountain-3.jpg',
            size: 5242880, // 5MB
            url: 'https://picsum.photos/seed/3/800/600',
            thumbnail: 'https://picsum.photos/seed/3/100/100',
        },
        {
            id: 4,
            name: 'ocean-sunset-4.jpg',
            size: 102400, // 100KB
            url: 'https://picsum.photos/seed/4/800/600',
            thumbnail: 'https://picsum.photos/seed/4/100/100',
        },
    ];

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
        this.showPopup = true;
    }

    closePopup(): void {
        this.showPopup = false;
        this.selectedImage = null;
    }

    onClear(): void {
        this.images = [];
        this.progress = 0;
    }

    onUpload(): void {
        this.isUploading = true;
        this.progress = 0;

        // Simulate upload progress
        const interval = setInterval(() => {
            this.progress += 10;
            if (this.progress >= 100) {
                clearInterval(interval);
                this.isUploading = false;
            }
        }, 500);
    }

    onSubmit(): void {
        const selectedImages = this.images.filter((img) => img.selected);
        console.log('Submitting images:', selectedImages);
    }

    toggleSelect(image: ImageItem): void {
        image.selected = !image.selected;
    }

    getSelectOptions(): string[] {
        return ['1', '2', '4'];
    }
}

import { Component, computed, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { InfoItem, MenuItem } from './models';
import { InputTextModule } from '@openng/optimus-ui/inputtext';
import { ButtonModule } from '@openng/optimus-ui/button';

@Component({
    selector: 'app-home',
    imports: [CommonModule, FormsModule, InputTextModule, ButtonModule],
    templateUrl: './home.html',
    styleUrl: './home.css',
})
export class Home {
    // Thông tin 4 items
    infoItems: InfoItem[] = [
        {
            icon: '🌐',
            label: 'Public IP',
            value: '192.168.1.1',
        },
        {
            icon: '📍',
            label: 'Location',
            value: 'Hanoi, Vietnam',
        },
        {
            icon: '🖥️',
            label: 'ISP',
            value: 'Viettel Telecom',
        },
        {
            icon: '🏙️',
            label: 'City',
            value: 'Hanoi',
        },
    ];

    // Danh sách menu
    menuItems: MenuItem[] = [
        { icon: '🖼️', name: 'Upscale Img', route: '/dashboard' },
        { icon: '🖼️', name: 'Split Img', route: '/profile' },
    ];

    // Biến lưu từ khóa tìm kiếm
    searchTerm: string = '';

    // Getter để lọc menu theo từ khóa tìm kiếm
    get filteredMenuItems(): MenuItem[] {
        if (!this.searchTerm.trim()) {
            return this.menuItems;
        }
        return this.menuItems.filter((item) =>
            item.name.toLowerCase().includes(this.searchTerm.toLowerCase()),
        );
    }
}

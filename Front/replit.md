# Sistema de Assistência Técnica

## Overview

This is a comprehensive technical assistance management system designed for equipment repair services. The application provides a complete workflow management solution from customer registration to service completion, including inventory control, budgeting, and reporting capabilities. Built as a single-page application with a client-side architecture, it features a multi-module interface covering all aspects of technical service operations including customer management, equipment tracking, service orders, inventory control, budgets, repair history, and analytics.

## User Preferences

Preferred communication style: Simple, everyday language.

## System Architecture

### Frontend Architecture
- **Single Page Application (SPA)**: Built with vanilla HTML, CSS, and JavaScript without external frameworks
- **Modular Navigation System**: Content sections are dynamically shown/hidden based on sidebar menu selections
- **Responsive Design**: CSS grid and flexbox layout with sidebar navigation and main content area
- **State Management**: Client-side state management using vanilla JavaScript with DOM manipulation

### UI/UX Design Patterns
- **Sidebar Navigation**: Fixed sidebar with icon-based menu items for different system modules
- **Content Sections**: Modular content areas that activate based on navigation selection
- **Visual Hierarchy**: Gray color scheme (#6c757d) with clear visual separation between sections
- **Logo Integration**: Placeholder system for custom branding with fallback text display

### Module Structure
The system is organized into 16 core modules:
- Dashboard with real-time overview
- Customer and equipment registration
- Service order management (OS)
- Inventory control with stock alerts
- Budget generation and approval workflow
- Repair history tracking
- Reports and analytics
- Technician scheduling and task management
- Equipment check-in/check-out system
- Communication integration (WhatsApp/SMS)
- Digital signature capabilities
- Photo and document attachments
- Warranty control system
- Multi-user access control
- Data backup and security
- ERP/accounting system integration

### Development Server
- **Python HTTP Server**: Simple development server using Python's built-in http.server module
- **Static File Serving**: Serves HTML, CSS, and JavaScript files with custom MIME type handling
- **Cache Control**: Implements no-cache headers for development purposes
- **Port Configuration**: Runs on port 5000 with localhost access

### Data Architecture Considerations
- **Client-Side Storage**: Currently designed for local storage or session-based data management
- **Modular Data Structure**: Separated concerns for customers, equipment, service orders, inventory, and financial data
- **Document Management**: Support for file attachments and digital signatures
- **Audit Trail**: Historical tracking capabilities for repairs and service records

## External Dependencies

### Core Technologies
- **HTML5**: Modern semantic markup structure
- **CSS3**: Styling with flexbox/grid layout and transitions
- **Vanilla JavaScript**: No external JavaScript frameworks or libraries
- **Python 3**: Development server using standard library modules

### Potential Integrations
Based on the system requirements, the following external services may be integrated:
- **WhatsApp Business API**: For automated customer communication
- **SMS Gateway Services**: For notification delivery
- **Digital Signature Services**: For document authentication
- **Cloud Storage**: For backup and file attachment storage
- **ERP/Accounting Systems**: For financial data synchronization
- **Payment Gateways**: For budget approval and payment processing

### Server Requirements
- **Python 3.x**: For running the development server
- **Web Browser**: Modern browser with JavaScript ES6+ support
- **File System Access**: For serving static assets and potential file uploads

Note: The current implementation is frontend-focused with a development server. Production deployment would require additional backend infrastructure, database integration, and security implementations for the complete feature set outlined in the requirements.
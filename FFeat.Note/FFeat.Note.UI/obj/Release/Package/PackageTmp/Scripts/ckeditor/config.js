/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
    config.toolbarGroups = [
        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
        { name: 'clipboard', groups: ['clipboard', 'undo'] },
        { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
        { name: 'document', groups: ['mode', 'document', 'doctools'] },
        { name: 'forms', groups: ['forms'] },
        { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
        '/',
        { name: 'links', groups: ['links'] },
        { name: 'insert', groups: ['insert'] },
        { name: 'styles', groups: ['styles'] },
        '/',
        { name: 'colors', groups: ['colors'] },
        { name: 'tools', groups: ['tools'] },
        { name: 'others', groups: ['others'] },
        { name: 'about', groups: ['about'] }
    ];

    config.removeButtons = 'Flash,Iframe,Language,BidiLtr,BidiRtl,CreateDiv,Outdent,Indent,Form,Checkbox,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField,Cut,Copy,Paste,PasteText,PasteFromWord,Source,Templates,Save,NewPage,Preview';
};
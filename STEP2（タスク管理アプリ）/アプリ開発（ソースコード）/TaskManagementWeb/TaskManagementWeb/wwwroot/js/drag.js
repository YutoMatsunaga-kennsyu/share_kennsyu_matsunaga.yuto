window.makeDraggable = (targetElementRef, handleElementRef) => {
    const targetElement = targetElementRef instanceof HTMLElement ? targetElementRef : document.getElementById(targetElementRef.id || targetElementRef._id);
    const handleElement = handleElementRef instanceof HTMLElement ? handleElementRef : document.getElementById(handleElementRef.id || handleElementRef._id);

    if (!targetElement || !handleElement) {
        console.error("makeDraggable: target or handle element not found", targetElement, handleElement);
        return;
    }

    let isMouseDown = false;
    let offset = { x: 0, y: 0 };

    function isInsideEditable(el) {
        while (el) {
            if (['INPUT', 'TEXTAREA', 'SELECT', 'BUTTON'].includes(el.tagName) || el.isContentEditable) {
                return true;
            }
            el = el.parentElement;
        }
        return false;
    }

    // ヘッダーでmousedownされた場合のみドラッグ開始
    handleElement.addEventListener('mousedown', (e) => {
        if (isInsideEditable(e.target)) return;

        isMouseDown = true;
        const rect = targetElement.getBoundingClientRect();
        offset.x = e.clientX - rect.left;
        offset.y = e.clientY - rect.top;

        targetElement.style.position = 'absolute';
        targetElement.style.zIndex = '1000';

        // prevent text selection while dragging
        e.preventDefault();
    });

    document.addEventListener('mousemove', (e) => {
        if (!isMouseDown) return;

        targetElement.style.left = `${e.clientX - offset.x}px`;
        targetElement.style.top = `${e.clientY - offset.y}px`;
    });

    document.addEventListener('mouseup', () => {
        isMouseDown = false;
    });
};

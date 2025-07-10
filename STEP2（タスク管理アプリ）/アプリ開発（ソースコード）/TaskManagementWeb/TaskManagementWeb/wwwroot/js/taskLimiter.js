window.setTextareaValue = function (id, value) {
    const el = document.getElementById(id);
    if (el) {
        el.value = value;
    }
};
window.initTextareaLimiter = function (id, maxLength) {
    const el = document.getElementById(id);
    if (!el) return;

    el.addEventListener('beforeinput', function (e) {
        // 現在の値＋これから入る文字の長さがmaxLengthを超えたらpreventDefaultして入力キャンセル
        const currentLength = el.value.length;
        const inputLength = e.data ? e.data.length : 0;
        if (currentLength + inputLength > maxLength) {
            e.preventDefault();
            el.blur();  // フォーカスも外す
            alert(`タスク名は${maxLength}文字以内で入力してください。`);
        }
    });
};
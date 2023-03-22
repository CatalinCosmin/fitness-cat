import { useEffect, useState } from "react"

const useLocalStorage = (storageKey: string, fallbackState: any) => {
    const [value, setValue] = useState(
        tryParse(localStorage.getItem(storageKey)) ?? fallbackState
    );
    useEffect(() => {
        localStorage.setItem(storageKey, JSON.stringify(value));
    }, [value, storageKey]);

    return [value, setValue];
}

const tryParse = (text: string | null) => {
    if(text === null) return null;
    try {
        return JSON.parse(text);
    }
    catch {
        return null;
    }
}

export default useLocalStorage;
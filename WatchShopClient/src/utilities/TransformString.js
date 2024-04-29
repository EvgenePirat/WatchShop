export const transformString = (name) => {
    const words = name.match(/[A-Z]?[a-z0-9]+/g);
    if (words != null) {
        const transformedWords = words.map((word, index) => {
            const formattedWord = word.replace(/_/g, ' ').replace(/^\w/, (c) => c.toUpperCase());
            if (index > 0 && /[A-Z]/.test(word[0])) {
                return ` ${formattedWord}`;
            }
            return formattedWord;
        });

        const transformedString = transformedWords.join('');

        return transformedString;
    }

    return name;
};
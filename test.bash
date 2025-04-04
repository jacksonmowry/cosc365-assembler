#!/usr/bin/env bash

for file in test_asm/*.asm; do
    echo "Testing: ${file_name}"

    file_name="${file%%.*}"

    tmp=$(mktemp)

    dotnet run -- "${file}" "${tmp}"

    diff -s "${file_name}.v" "${tmp}"

    rm "${tmp}"
done

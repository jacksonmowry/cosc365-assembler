#!/usr/bin/env bash

dotnet build

for file in test_asm/*.asm; do
    echo "Testing: ${file_name}"

    file_name="${file%%.*}"

    tmp=$(mktemp)

    bin/Debug/net8.0/assembler "${file}" "${tmp}"

    diff -s "${file_name}.v" "${tmp}"

    rm "${tmp}"
done

| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.094 μs | 0.0019 μs | 0.0018 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     2.554 μs | 0.0060 μs | 0.0056 μs |    1312 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128B         |     1.098 μs | 0.0026 μs | 0.0024 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128B         |     2.456 μs | 0.0100 μs | 0.0094 μs |    1312 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |     7.794 μs | 0.0176 μs | 0.0156 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    15.695 μs | 0.0995 μs | 0.0931 μs |    3552 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 1KB          |     7.837 μs | 0.0285 μs | 0.0267 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 1KB          |    15.391 μs | 0.0351 μs | 0.0329 μs |    3552 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |    60.589 μs | 0.2430 μs | 0.2273 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   119.652 μs | 0.4145 μs | 0.3877 μs |   21472 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 8KB          |    61.558 μs | 0.0869 μs | 0.0725 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 8KB          |   118.044 μs | 0.3689 μs | 0.3451 μs |   21472 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        |   968.377 μs | 2.6180 μs | 2.4489 μs |         - |
| Decrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 1,897.933 μs | 5.8420 μs | 5.4646 μs |  328672 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-192-CBC (CryptoHives-Scalar) | 128KB        |   986.624 μs | 3.1109 μs | 2.9099 μs |         - |
| Encrypt · ARIA-192-CBC (BouncyCastle)       | 128KB        | 1,887.529 μs | 4.7874 μs | 4.4782 μs |  328672 B |
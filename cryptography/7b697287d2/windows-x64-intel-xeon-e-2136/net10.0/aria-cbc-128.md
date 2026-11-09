| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     2.826 μs | 0.0040 μs | 0.0032 μs |   1,311 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     3.620 μs | 0.0067 μs | 0.0056 μs |   2,919 B |    1208 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     2.876 μs | 0.0051 μs | 0.0048 μs |   1,307 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     3.420 μs | 0.0074 μs | 0.0066 μs |   2,935 B |    1208 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    19.780 μs | 0.0347 μs | 0.0324 μs |   1,311 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    21.428 μs | 0.0632 μs | 0.0591 μs |   2,935 B |    3448 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    20.448 μs | 0.3869 μs | 0.3231 μs |   1,307 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    20.717 μs | 0.0616 μs | 0.0546 μs |   2,935 B |    3448 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |   155.325 μs | 0.3768 μs | 0.3524 μs |   1,311 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   172.319 μs | 0.2658 μs | 0.2219 μs |   2,933 B |   21368 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |   158.668 μs | 0.1783 μs | 0.1580 μs |   1,305 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   163.344 μs | 0.3885 μs | 0.3444 μs |   2,935 B |   21368 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 2,478.326 μs | 5.0201 μs | 4.6958 μs |   1,311 B |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 2,639.180 μs | 6.1456 μs | 5.4479 μs |   2,933 B |  328568 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 2,534.143 μs | 3.8666 μs | 3.6168 μs |   1,311 B |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 2,613.091 μs | 5.7541 μs | 5.3824 μs |   2,933 B |  328568 B |
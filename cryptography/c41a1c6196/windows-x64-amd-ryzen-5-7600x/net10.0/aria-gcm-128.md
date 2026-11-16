| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128B         |     1.656 μs | 0.0066 μs | 0.0058 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128B         |     2.510 μs | 0.0501 μs | 0.0444 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 128B         |     3.124 μs | 0.0085 μs | 0.0076 μs |     306 B |    2040 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128B         |     1.621 μs | 0.0054 μs | 0.0048 μs |     383 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128B         |     2.049 μs | 0.0057 μs | 0.0045 μs |     383 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 128B         |     2.990 μs | 0.0079 μs | 0.0074 μs |     386 B |    2024 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 1KB          |    11.468 μs | 0.0322 μs | 0.0285 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 1KB          |    14.396 μs | 0.0329 μs | 0.0307 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 1KB          |    17.437 μs | 0.0696 μs | 0.0651 μs |     306 B |    4280 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 1KB          |    11.430 μs | 0.0359 μs | 0.0318 μs |     386 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 1KB          |    14.387 μs | 0.0849 μs | 0.0753 μs |     383 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 1KB          |    17.243 μs | 0.0415 μs | 0.0368 μs |     383 B |    4264 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 8KB          |    90.066 μs | 0.2322 μs | 0.2172 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 8KB          |   112.729 μs | 0.2996 μs | 0.2656 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 8KB          |   132.799 μs | 0.3450 μs | 0.3227 μs |     306 B |   22200 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 8KB          |    89.932 μs | 0.3804 μs | 0.3372 μs |     383 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 8KB          |   112.884 μs | 0.3841 μs | 0.3405 μs |     383 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 8KB          |   132.080 μs | 0.4121 μs | 0.3442 μs |     383 B |   22184 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128KB        | 1,438.048 μs | 5.3010 μs | 4.6992 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128KB        | 1,806.129 μs | 6.3670 μs | 5.3168 μs |     306 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 128KB        | 2,098.749 μs | 6.3944 μs | 5.3396 μs |     306 B |  329400 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128KB        | 1,435.626 μs | 2.8326 μs | 2.2115 μs |     383 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128KB        | 1,809.251 μs | 3.2630 μs | 2.8925 μs |     383 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 128KB        | 2,093.782 μs | 7.6029 μs | 7.1118 μs |     383 B |  329384 B |
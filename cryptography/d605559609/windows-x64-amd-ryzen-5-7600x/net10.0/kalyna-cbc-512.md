| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     3.895 μs |  0.0281 μs |  0.0235 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     5.631 μs |  0.0369 μs |  0.0327 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     2.479 μs |  0.0154 μs |  0.0129 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     3.417 μs |  0.0155 μs |  0.0137 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    25.701 μs |  0.1157 μs |  0.1026 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    31.673 μs |  0.4592 μs |  0.5104 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    16.276 μs |  0.0860 μs |  0.0804 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    17.644 μs |  0.1286 μs |  0.1203 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   198.713 μs |  1.0974 μs |  1.0265 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   238.060 μs |  1.2609 μs |  0.9844 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   127.323 μs |  2.1419 μs |  2.8594 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   131.313 μs |  1.1889 μs |  1.1121 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 3,165.781 μs | 14.3721 μs | 13.4437 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 3,804.082 μs | 26.4192 μs | 24.7125 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 2,007.735 μs | 15.9054 μs | 14.0997 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 2,066.768 μs | 22.3000 μs | 18.6215 μs |    1784 B |
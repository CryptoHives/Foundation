| Description                                   | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     3.465 μs |  0.0153 μs |  0.0135 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     4.915 μs |  0.0180 μs |  0.0159 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     1.896 μs |  0.0055 μs |  0.0043 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     2.615 μs |  0.0062 μs |  0.0058 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    22.508 μs |  0.0735 μs |  0.0651 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    27.481 μs |  0.0881 μs |  0.0825 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    12.951 μs |  0.0683 μs |  0.0533 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    13.198 μs |  0.0563 μs |  0.0499 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   174.881 μs |  0.6053 μs |  0.5054 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   210.082 μs |  0.7219 μs |  0.6400 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |    96.528 μs |  0.3687 μs |  0.2879 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |    97.201 μs |  0.4038 μs |  0.3777 μs |    1784 B |
|                                               |              |              |            |            |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 2,791.775 μs |  9.5434 μs |  7.4509 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 3,344.331 μs | 22.0060 μs | 19.5077 μs |    1784 B |
|                                               |              |              |            |            |           |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 1,532.081 μs |  9.3739 μs |  8.7684 μs |    1784 B |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 1,540.466 μs |  5.1793 μs |  4.8447 μs |         - |
| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128B         |     1.150 μs | 0.0060 μs | 0.0053 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128B         |     1.614 μs | 0.0080 μs | 0.0075 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 128B         |     1.679 μs | 0.0136 μs | 0.0127 μs |     306 B |    1440 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128B         |     1.110 μs | 0.0021 μs | 0.0019 μs |     386 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 128B         |     1.498 μs | 0.0027 μs | 0.0022 μs |     386 B |    1424 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128B         |     1.534 μs | 0.0053 μs | 0.0044 μs |     386 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 1KB          |     7.926 μs | 0.0357 μs | 0.0334 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 1KB          |     8.693 μs | 0.0501 μs | 0.0469 μs |     306 B |    3680 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 1KB          |    10.764 μs | 0.0694 μs | 0.0649 μs |     306 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 1KB          |     7.764 μs | 0.0193 μs | 0.0161 μs |     386 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 1KB          |     8.516 μs | 0.0333 μs | 0.0278 μs |     386 B |    3664 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 1KB          |    10.688 μs | 0.0602 μs | 0.0534 μs |     386 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 8KB          |    61.465 μs | 0.3064 μs | 0.2866 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 8KB          |    65.038 μs | 0.4938 μs | 0.4377 μs |     306 B |   21600 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 8KB          |    83.625 μs | 0.5499 μs | 0.4874 μs |     306 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 8KB          |    61.837 μs | 0.0733 μs | 0.0612 μs |     386 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 8KB          |    65.022 μs | 0.2135 μs | 0.1782 μs |     386 B |   21584 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 8KB          |    83.014 μs | 0.1015 μs | 0.0848 μs |     386 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128KB        |   979.823 μs | 4.2030 μs | 3.7259 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 128KB        | 1,037.556 μs | 5.3445 μs | 4.9993 μs |     306 B |  328800 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128KB        | 1,326.125 μs | 6.1143 μs | 5.1057 μs |     306 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128KB        |   982.310 μs | 2.9823 μs | 2.7897 μs |     386 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 128KB        | 1,041.720 μs | 3.8481 μs | 3.4112 μs |     386 B |  328784 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128KB        | 1,338.819 μs | 4.2675 μs | 3.9918 μs |     386 B |         - |
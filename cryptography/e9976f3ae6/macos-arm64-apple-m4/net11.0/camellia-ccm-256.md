| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     2.096 μs | 0.0087 μs | 0.0082 μs |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     2.685 μs | 0.0092 μs | 0.0086 μs |    2200 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     2.047 μs | 0.0149 μs | 0.0140 μs |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     2.619 μs | 0.0109 μs | 0.0096 μs |    2048 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    13.394 μs | 0.0522 μs | 0.0463 μs |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    15.597 μs | 0.0983 μs | 0.0920 μs |    7576 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    13.683 μs | 0.2398 μs | 0.2566 μs |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    15.473 μs | 0.1134 μs | 0.1005 μs |    6528 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   103.620 μs | 0.2221 μs | 0.2077 μs |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   119.407 μs | 0.3045 μs | 0.2849 μs |   50584 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   103.412 μs | 0.1934 μs | 0.1615 μs |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   118.943 μs | 0.2505 μs | 0.2343 μs |   42368 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 1,663.582 μs | 6.0447 μs | 5.6542 μs |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 1,922.571 μs | 5.5915 μs | 5.2303 μs |  787890 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 1,677.445 μs | 4.5016 μs | 4.2108 μs |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 1,893.153 μs | 4.2614 μs | 3.9861 μs |  656768 B |
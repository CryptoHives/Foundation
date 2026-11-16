| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128B         |     1.212 μs | 0.0024 μs | 0.0021 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128B         |     1.697 μs | 0.0023 μs | 0.0019 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 128B         |     1.746 μs | 0.0048 μs | 0.0045 μs |     306 B |    1440 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128B         |     1.158 μs | 0.0024 μs | 0.0020 μs |     383 B |         - |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128B         |     1.606 μs | 0.0021 μs | 0.0018 μs |     383 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 128B         |     1.624 μs | 0.0046 μs | 0.0043 μs |     383 B |    1424 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 1KB          |     8.273 μs | 0.0199 μs | 0.0176 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 1KB          |     9.501 μs | 0.0425 μs | 0.0397 μs |     306 B |    3680 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 1KB          |    11.278 μs | 0.0242 μs | 0.0202 μs |     306 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 1KB          |     8.206 μs | 0.0164 μs | 0.0145 μs |     386 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 1KB          |     9.347 μs | 0.0225 μs | 0.0200 μs |     383 B |    3664 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 1KB          |    11.147 μs | 0.0253 μs | 0.0224 μs |     386 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 8KB          |    64.596 μs | 0.1485 μs | 0.1317 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 8KB          |    71.118 μs | 0.1303 μs | 0.1219 μs |     306 B |   21600 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 8KB          |    87.769 μs | 0.2072 μs | 0.1731 μs |     306 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 8KB          |    64.527 μs | 0.1242 μs | 0.1101 μs |     383 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 8KB          |    70.945 μs | 0.1811 μs | 0.1606 μs |     383 B |   21584 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 8KB          |    88.987 μs | 0.1877 μs | 0.1664 μs |     383 B |         - |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128KB        | 1,042.016 μs | 1.9417 μs | 1.8163 μs |     306 B |         - |
| Decrypt · Camellia-256-GCM (BouncyCastle)       | 128KB        | 1,130.809 μs | 2.2295 μs | 1.8617 μs |     306 B |  328800 B |
| Decrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128KB        | 1,400.184 μs | 5.4954 μs | 4.8715 μs |     306 B |         - |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-GCM (CryptoHives-PClMul) | 128KB        | 1,047.136 μs | 3.1559 μs | 2.7976 μs |     383 B |         - |
| Encrypt · Camellia-256-GCM (BouncyCastle)       | 128KB        | 1,127.004 μs | 1.8917 μs | 1.4769 μs |     383 B |  328784 B |
| Encrypt · Camellia-256-GCM (CryptoHives-Scalar) | 128KB        | 1,407.968 μs | 2.6125 μs | 2.4437 μs |     383 B |         - |
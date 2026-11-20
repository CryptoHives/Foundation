| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     1.352 μs | 0.0017 μs | 0.0015 μs |   4,026 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     2.161 μs | 0.0046 μs | 0.0043 μs |  13,735 B |     584 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     1.628 μs | 0.0011 μs | 0.0010 μs |   4,026 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     2.017 μs | 0.0077 μs | 0.0072 μs |  13,735 B |     584 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     9.375 μs | 0.0075 μs | 0.0067 μs |  10,361 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |    13.758 μs | 0.0176 μs | 0.0165 μs |  13,735 B |    2824 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |    11.458 μs | 0.0056 μs | 0.0053 μs |  10,551 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |    13.705 μs | 0.0225 μs | 0.0200 μs |  13,735 B |    2824 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    72.979 μs | 0.0474 μs | 0.0396 μs |   4,026 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |   107.597 μs | 0.1550 μs | 0.1449 μs |   7,776 B |   20744 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    89.959 μs | 0.0333 μs | 0.0295 μs |  10,551 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |   100.525 μs | 0.1741 μs | 0.1628 μs |  13,735 B |   20744 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 1,170.036 μs | 0.6398 μs | 0.5671 μs |  10,551 B |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,706.656 μs | 2.0717 μs | 1.9379 μs |  13,735 B |  327944 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 1,429.930 μs | 0.5341 μs | 0.4996 μs |  10,551 B |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,639.040 μs | 4.1978 μs | 3.9266 μs |  13,737 B |  327944 B |
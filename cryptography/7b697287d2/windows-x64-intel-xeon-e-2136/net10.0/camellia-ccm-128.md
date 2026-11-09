| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     2.377 μs | 0.0063 μs | 0.0059 μs |  18,775 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     3.306 μs | 0.0044 μs | 0.0039 μs |     310 B |    2184 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     2.306 μs | 0.0060 μs | 0.0050 μs |  18,831 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     3.225 μs | 0.0098 μs | 0.0092 μs |     387 B |    2072 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    14.816 μs | 0.0590 μs | 0.0493 μs |  18,779 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    18.720 μs | 0.0484 μs | 0.0453 μs |     310 B |    7560 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    14.690 μs | 0.0359 μs | 0.0336 μs |  18,832 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    18.528 μs | 0.0438 μs | 0.0366 μs |     387 B |    6552 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |   114.097 μs | 0.2775 μs | 0.2596 μs |  18,783 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |   141.447 μs | 0.4363 μs | 0.4081 μs |     310 B |   50568 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |   113.955 μs | 0.2761 μs | 0.2583 μs |  18,836 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |   139.712 μs | 0.3863 μs | 0.3226 μs |     387 B |   42392 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 1,814.628 μs | 5.0339 μs | 4.7088 μs |  18,783 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 2,304.366 μs | 7.5000 μs | 7.0155 μs |     310 B |  787861 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 1,811.880 μs | 4.1602 μs | 3.8915 μs |  18,836 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 2,219.806 μs | 4.8487 μs | 4.5355 μs |     387 B |  656792 B |
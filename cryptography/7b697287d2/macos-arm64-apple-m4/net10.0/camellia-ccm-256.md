| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     2.065 μs | 0.0109 μs | 0.0102 μs |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     2.737 μs | 0.0141 μs | 0.0132 μs |    2232 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128B         |     2.021 μs | 0.0101 μs | 0.0094 μs |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128B         |     2.665 μs | 0.0115 μs | 0.0108 μs |    2120 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    13.114 μs | 0.0659 μs | 0.0617 μs |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    15.819 μs | 0.0845 μs | 0.0790 μs |    7608 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 1KB          |    12.983 μs | 0.0462 μs | 0.0432 μs |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 1KB          |    15.775 μs | 0.0764 μs | 0.0715 μs |    6600 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   101.412 μs | 0.5106 μs | 0.4777 μs |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   120.079 μs | 0.4890 μs | 0.4574 μs |   50616 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 8KB          |   101.216 μs | 0.4277 μs | 0.4001 μs |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 8KB          |   120.101 μs | 0.6585 μs | 0.6160 μs |   42440 B |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 1,622.823 μs | 7.5403 μs | 7.0532 μs |         - |
| Decrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 1,945.135 μs | 7.8951 μs | 7.3851 μs |  787924 B |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-256-CCM (CryptoHives-Scalar) | 128KB        | 1,621.454 μs | 6.5964 μs | 6.1703 μs |         - |
| Encrypt · Camellia-256-CCM (BouncyCastle)       | 128KB        | 1,906.794 μs | 9.8788 μs | 9.2407 μs |  656840 B |
| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1.236 μs | 0.0042 μs | 0.0039 μs |     584 B |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     1.768 μs | 0.0024 μs | 0.0022 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1.233 μs | 0.0036 μs | 0.0034 μs |     584 B |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |     1.762 μs | 0.0048 μs | 0.0045 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8.173 μs | 0.0224 μs | 0.0209 μs |    2824 B |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |    12.699 μs | 0.0194 μs | 0.0162 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8.172 μs | 0.0200 μs | 0.0187 μs |    2824 B |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |    12.678 μs | 0.0275 μs | 0.0257 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    63.920 μs | 0.2255 μs | 0.1999 μs |   20744 B |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |   100.108 μs | 0.2153 μs | 0.2014 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    62.978 μs | 0.1995 μs | 0.1666 μs |   20744 B |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |   102.859 μs | 0.2755 μs | 0.2301 μs |         - |
|                                                 |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,019.816 μs | 3.8777 μs | 3.6272 μs |  327944 B |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 1,598.901 μs | 3.6409 μs | 3.4057 μs |         - |
|                                                 |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,025.239 μs | 4.5628 μs | 4.2680 μs |  327944 B |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        | 1,601.669 μs | 9.3909 μs | 8.7842 μs |         - |
| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       857.8 ns |     1.97 ns |     1.75 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,279.8 ns |     4.17 ns |     3.69 ns |     584 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       921.8 ns |     0.34 ns |     0.30 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,201.2 ns |     0.61 ns |     0.57 ns |     584 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     6,076.3 ns |     1.74 ns |     1.55 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     7,892.0 ns |     4.84 ns |     4.29 ns |    2824 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     6,684.7 ns |     7.98 ns |     7.47 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     7,980.0 ns |     7.94 ns |     7.04 ns |    2824 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    48,293.6 ns |    29.70 ns |    26.33 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    60,862.6 ns |    63.69 ns |    56.46 ns |   20744 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    52,683.3 ns |    63.60 ns |    59.49 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    61,644.6 ns |   128.50 ns |   113.91 ns |   20744 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   766,567.8 ns |   471.24 ns |   417.74 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        |   973,020.9 ns | 1,558.92 ns | 1,458.22 ns |  327944 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   860,382.0 ns | 1,594.06 ns | 1,331.11 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,007,652.2 ns | 4,483.30 ns | 4,193.68 ns |  327944 B |
| Description                                     | TestDataSize | Mean         | Error       | StdDev       | Median       | Allocated |
|------------------------------------------------ |------------- |-------------:|------------:|-------------:|-------------:|----------:|
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     601.8 ns |     0.07 ns |      0.07 ns |     601.8 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     911.5 ns |     0.35 ns |      0.29 ns |     911.5 ns |     576 B |
|                                                 |              |              |             |              |              |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     682.8 ns |     0.22 ns |      0.19 ns |     682.7 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     939.1 ns |     3.22 ns |      2.69 ns |     937.9 ns |     576 B |
|                                                 |              |              |             |              |              |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,229.7 ns |     0.91 ns |      0.76 ns |   4,229.7 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |   5,941.8 ns |     4.97 ns |      4.65 ns |   5,942.4 ns |    2816 B |
|                                                 |              |              |             |              |              |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |   4,948.5 ns |     1.06 ns |      0.94 ns |   4,948.1 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |  12,231.2 ns | 3,412.53 ns | 10,061.93 ns |   6,211.6 ns |    2816 B |
|                                                 |              |              |             |              |              |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  33,557.9 ns |     9.30 ns |      8.25 ns |  33,558.0 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  46,111.1 ns |    73.78 ns |     69.02 ns |  46,111.6 ns |   20736 B |
|                                                 |              |              |             |              |              |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |  38,957.0 ns |    13.87 ns |     12.97 ns |  38,961.6 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |  47,552.8 ns |    44.41 ns |     41.54 ns |  47,561.2 ns |   20736 B |
|                                                 |              |              |             |              |              |           |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 534,780.9 ns |   375.62 ns |    332.98 ns | 534,843.2 ns |         - |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 891,636.6 ns | 3,892.23 ns |  3,640.79 ns | 891,435.2 ns |  327936 B |
|                                                 |              |              |             |              |              |           |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 622,484.9 ns |   186.58 ns |    174.53 ns | 622,476.3 ns |         - |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 759,877.7 ns | 1,872.05 ns |  1,751.12 ns | 760,079.9 ns |  327936 B |
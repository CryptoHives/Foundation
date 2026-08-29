| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Median         | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|---------------:|----------:|
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       767.4 ns |     2.22 ns |     1.85 ns |       767.9 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,245.0 ns |     5.47 ns |     4.85 ns |     1,244.8 ns |     584 B |
|                                                 |              |                |             |             |                |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128B         |       821.3 ns |     5.17 ns |     4.83 ns |       820.5 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128B         |     1,268.4 ns |    24.98 ns |    50.46 ns |     1,240.1 ns |     584 B |
|                                                 |              |                |             |             |                |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     5,439.3 ns |    69.95 ns |    62.01 ns |     5,417.8 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8,366.8 ns |    39.32 ns |    32.84 ns |     8,365.3 ns |    2824 B |
|                                                 |              |                |             |             |                |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 1KB          |     5,717.5 ns |    42.02 ns |    39.31 ns |     5,713.2 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 1KB          |     8,277.1 ns |    38.72 ns |    36.22 ns |     8,274.9 ns |    2824 B |
|                                                 |              |                |             |             |                |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    44,223.0 ns |   338.41 ns |   282.59 ns |    44,078.7 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    66,145.4 ns |   382.26 ns |   357.57 ns |    66,090.3 ns |   20744 B |
|                                                 |              |                |             |             |                |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 8KB          |    45,187.1 ns |   315.46 ns |   279.65 ns |    45,079.8 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 8KB          |    64,727.5 ns |   405.41 ns |   379.22 ns |    64,674.5 ns |   20744 B |
|                                                 |              |                |             |             |                |           |
| Decrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   694,959.8 ns | 2,748.37 ns | 2,436.35 ns |   694,936.7 ns |         - |
| Decrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,044,124.1 ns | 5,280.48 ns | 4,939.37 ns | 1,044,097.3 ns |  327944 B |
|                                                 |              |                |             |             |                |           |
| Encrypt · Camellia-192-CBC (CryptoHives-Scalar) | 128KB        |   726,236.3 ns | 3,613.12 ns | 3,017.12 ns |   726,205.8 ns |         - |
| Encrypt · Camellia-192-CBC (BouncyCastle)       | 128KB        | 1,032,672.3 ns | 7,172.36 ns | 5,989.25 ns | 1,033,536.5 ns |  327944 B |
| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |     406.2 ns |     0.58 ns |     0.52 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |   1,026.0 ns |     3.44 ns |     3.05 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128B         |   1,640.9 ns |     3.78 ns |     3.35 ns |    2424 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128B         |     370.7 ns |     2.56 ns |     2.40 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128B         |   1,202.6 ns |    11.25 ns |     9.97 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128B         |   1,772.6 ns |    11.35 ns |    17.34 ns |    2464 B |
|                                            |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |   2,312.6 ns |     2.95 ns |     2.61 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |   6,506.7 ns |    21.36 ns |    19.98 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 1KB          |   8,262.8 ns |    24.40 ns |    21.63 ns |    2424 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 1KB          |   2,341.4 ns |    10.56 ns |     9.88 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 1KB          |   6,766.3 ns |   131.49 ns |   122.99 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 1KB          |   8,259.5 ns |    55.33 ns |    51.75 ns |    2464 B |
|                                            |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |  17,587.7 ns |    32.74 ns |    29.03 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |  49,560.8 ns |    86.50 ns |    76.68 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 8KB          |  60,749.2 ns |   147.20 ns |   122.92 ns |    2424 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 8KB          |  17,599.4 ns |    42.48 ns |    37.66 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 8KB          |  49,970.9 ns |   348.39 ns |   308.84 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 8KB          |  60,903.8 ns |   202.60 ns |   179.60 ns |    2464 B |
|                                            |              |              |             |             |           |
| Decrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        | 278,845.4 ns |   262.89 ns |   245.91 ns |         - |
| Decrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 793,776.4 ns | 3,275.83 ns | 2,903.93 ns |         - |
| Decrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 959,488.9 ns | 2,176.74 ns | 2,036.12 ns |    2424 B |
|                                            |              |              |             |             |           |
| Encrypt · AES-128-CCM (CryptoHives-AES-NI) | 128KB        | 279,600.1 ns |   461.70 ns |   360.46 ns |         - |
| Encrypt · AES-128-CCM (CryptoHives-Scalar) | 128KB        | 795,114.2 ns | 2,637.06 ns | 2,466.71 ns |         - |
| Encrypt · AES-128-CCM (BouncyCastle)       | 128KB        | 967,299.1 ns | 5,840.19 ns | 4,876.82 ns |    2464 B |
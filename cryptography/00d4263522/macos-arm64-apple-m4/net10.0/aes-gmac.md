| Description                                | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      59.16 ns |   0.244 ns |   0.228 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     577.10 ns |   0.876 ns |   0.820 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      66.65 ns |   0.309 ns |   0.289 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     598.09 ns |   1.440 ns |   1.347 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     584.29 ns |   0.334 ns |   0.313 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   2,243.88 ns |   8.453 ns |   7.907 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     594.47 ns |   1.072 ns |   1.003 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   2,279.38 ns |   1.402 ns |   1.243 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |   5,017.09 ns |   2.257 ns |   2.111 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |  15,557.25 ns |  51.076 ns |  47.777 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  80,457.88 ns | 189.090 ns | 167.624 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 248,190.96 ns | 399.110 ns | 373.328 ns |    1728 B |
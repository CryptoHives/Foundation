| Description                                | TestDataSize | Mean          | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      65.27 ns |   0.151 ns |   0.126 ns |  11,437 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     491.81 ns |   3.236 ns |   2.869 ns |  21,169 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      74.15 ns |   0.182 ns |   0.162 ns |  11,425 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     503.06 ns |   3.614 ns |   3.018 ns |  21,770 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     271.12 ns |   1.581 ns |   1.479 ns |  11,437 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   1,321.12 ns |   6.018 ns |   5.335 ns |  21,172 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     275.94 ns |   3.641 ns |   3.405 ns |  11,430 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   1,325.55 ns |   4.317 ns |   3.605 ns |  21,768 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |   1,934.50 ns |   6.130 ns |   5.119 ns |  11,680 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |   7,894.89 ns |  31.309 ns |  27.755 ns |  20,906 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  30,523.12 ns | 166.406 ns | 147.515 ns |  11,680 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 124,124.96 ns | 160.230 ns | 142.040 ns |  21,116 B |    1816 B |
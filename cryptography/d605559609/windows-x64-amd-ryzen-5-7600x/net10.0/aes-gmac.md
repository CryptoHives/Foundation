| Description                                | TestDataSize | Mean          | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      65.28 ns |   0.258 ns |   0.254 ns |  11,437 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     483.44 ns |   2.027 ns |   1.692 ns |  21,172 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      74.21 ns |   0.154 ns |   0.136 ns |  11,428 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     503.24 ns |   5.482 ns |   5.128 ns |  21,762 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     275.44 ns |   1.545 ns |   1.445 ns |  11,201 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   1,310.30 ns |  23.783 ns |  18.568 ns |  21,174 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     285.00 ns |   0.912 ns |   0.809 ns |  11,430 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   1,322.15 ns |   8.134 ns |   6.792 ns |  21,779 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |   1,939.18 ns |  15.411 ns |  13.661 ns |  11,680 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |   7,876.28 ns |  21.002 ns |  16.397 ns |  20,906 B |    1816 B |
|                                            |              |               |            |            |           |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  30,538.57 ns | 190.412 ns | 187.010 ns |  11,680 B |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 123,206.91 ns | 766.750 ns | 679.704 ns |  21,114 B |    1816 B |
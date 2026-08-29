| Description                                | TestDataSize | Mean          | Error      | StdDev     | Allocated |
|------------------------------------------- |------------- |--------------:|-----------:|-----------:|----------:|
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128B         |      60.06 ns |   0.029 ns |   0.024 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128B         |     574.67 ns |   0.951 ns |   0.794 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 137B         |      68.08 ns |   0.095 ns |   0.084 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 137B         |     605.45 ns |   0.348 ns |   0.291 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1KB          |     603.34 ns |   4.010 ns |   3.555 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1KB          |   2,293.09 ns |   3.891 ns |   3.249 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 1025B        |     610.90 ns |   2.342 ns |   1.956 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 1025B        |   2,323.16 ns |   0.999 ns |   0.834 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 8KB          |   5,065.42 ns |  37.844 ns |  35.400 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 8KB          |  15,967.37 ns |   3.824 ns |   3.193 ns |    1728 B |
|                                            |              |               |            |            |           |
| ComputeTag · AES-GMAC · CryptoHives-Scalar | 128KB        |  81,232.18 ns | 802.008 ns | 710.959 ns |         - |
| ComputeTag · AES-GMAC · BouncyCastle       | 128KB        | 253,866.72 ns | 141.762 ns | 110.678 ns |    1728 B |
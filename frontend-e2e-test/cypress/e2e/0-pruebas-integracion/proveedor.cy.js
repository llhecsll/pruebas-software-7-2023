describe("CRUD Proveedor", () => {//Titulo
    //Antes que nada, abrir el navegador en el proyecto Frontend que es el puerto 8100
    beforeEach(() => {
        cy.visit("http://localhost:8100"); //Frontend de Produccion
    });

    //Servicio API - GetProveedor()
    it("GetProveedor()", () => {
        cy.wait(1000);//Esperar 1 seg.
        cy.get("ion-tab-button").eq(4).click(); // click en el TAB de Proveedor
        cy.wait(1000);//Esperar 1 seg.

        cy.get("ion-item").should("be.visible")
        .should("not.have.length", "0"); //Verifica que exista al menos un (ion-item)
    });

    //Servicio API - addProveedor()
    it("addProveedor", () => {
        cy.wait(1000);
        cy.get("ion-tab-button").eq(4).click();
        cy.wait(1000);

        // Ingresa los datos en los campos correspondientes
       // cy.get("#id").type("123");
        cy.get("#razonSocial").type("Razón Social de Prueba");
        cy.get("#nit").type("123456789");
        cy.get("#direccion").type("Dirección de Prueba");
        cy.get("#nombreProveedor").type("Proveedor de Prueba");
        cy.get("#telefono").type("987654321");
        cy.get("#email").type("prueba@example.com");

        // Haz clic en el botón "Agregar Proveedor"
        cy.get("#addProveedor").click();

        // Verifica que los datos del proveedor agregado sean correctos
       // cy.get("div").contains("strong", "ID:").next().should("contain", "123");
        //cy.get("div").contains("strong", "Razón Social:").next().should("contain", "Razón Social de Prueba");
        // ... Verifica los otros campos ...


    });

    //Servicio API - addProveedor()
    it("updateProveedor", () => {
        cy.wait(1000);
        cy.get("ion-tab-button").eq(4).click();
        cy.wait(1000);

        // Ingresa el ID del proveedor que deseas actualizar en el campo "id"
        const proveedorId = 1;
        cy.get("#id").type(proveedorId);

        // Ingresa los nuevos datos en los campos correspondientes
        cy.get("#razonSocial").type("Nueva Razón Social");
        cy.get("#nit").type("123456788");
        cy.get("#direccion").type("Nueva Dirección de Prueba");
        cy.get("#nombreProveedor").type("Nuevo Proveedor de Prueba");
        cy.get("#telefono").type("987654322");
        cy.get("#email").type("newprueba@example.com");

        // Haz clic en el botón "Actualizar Proveedor"
        cy.get("#updateProveedor").click();

        // Verifica que los datos del proveedor actualizado sean correctos
       // cy.get("div").contains("strong", "ID:").next().should("contain", proveedorId);
       // cy.get("div").contains("strong", "Razón Social:").next().should("contain", "Nueva Razón Social");
        // ... Verificar los otros campos ...

    });

    it("getById", () => {
        cy.wait(1000);
        cy.get("ion-tab-button").eq(4).click();
        cy.wait(1000);

        // Ingresa el ID del proveedor que deseas obtener en el campo "id"
        const proveedorId = 1;
        cy.get("#id").type(proveedorId);

        // Haz clic en el botón "Obtener Proveedor"
        cy.get("#getById").click();

        // Verifica que los datos del proveedor obtenido sean correctos
       // cy.get("div").contains("strong", "ID:").next().should("contain", proveedorId);
        // ... Verificar los otros campos ...

    });

    it("deleteProveedor", () => {
        cy.wait(1000);
        cy.get("ion-tab-button").eq(4).click();
        cy.wait(1000);

        // Ingresa el ID del proveedor que deseas eliminar en el campo "id"
        const proveedorId = 59;
        cy.get("#id").type(proveedorId);

        // Haz clic en el botón "Eliminar Proveedor"
        cy.get("#deleteProveedor").click();

        // Confirma la eliminación en el cuadro de diálogo (si tu aplicación muestra uno)
        // Puedes usar el selector correcto para el botón de confirmación

        // Verifica que el proveedor haya sido eliminado
        //cy.get("ion-item").should("not.contain", proveedorId);

    });

});
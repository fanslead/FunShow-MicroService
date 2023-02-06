<template>
  <BasicModal v-bind="$attrs" @register="register" title="更新权限" @ok="handleOk" />
</template>
<script lang="ts">
  import { defineComponent, ref } from 'vue'
  import { BasicModal, useModalInner } from '/@/components/Modal'
  import { useMessage } from '/@/hooks/web/useMessage'
  import { getPermissions, updatePermissions } from '/@/api/admin/permission'
  import { PermissionModel, UpdatePermissionParams } from '/@/api/admin/model/permissionModel'
  export default defineComponent({
    components: { BasicModal },
    props: {
      permissionData: { type: Object },
    },
    setup(props, ctx) {
      const modelRef = ref({} as PermissionModel)
      const roleRef = ref('')
      const selectPermission = ref({} as UpdatePermissionParams)
      const { createMessage } = useMessage()
      const { success, error } = createMessage
      const [register, { closeModal }] = useModalInner((data) => {
        data && onDataReceive(data)
      })
      function onDataReceive(data) {
        roleRef.value = data.name
        getPermissions('R', data.name).then((res) => {
          modelRef.value = res
        })
        // 方式1;
        // setFieldsValue({
        //   field2: data.data,
        //   field1: data.info,
        // });
        // // 方式2
        // modelRef.value = { field2: data.data, field1: data.info }
        // setProps({
        //   model:{ field2: data.data, field1: data.info }
        // })
      }
      function handleOk() {
        updatePermissions('R', roleRef.value, selectPermission.value)
          .then(() => {
            success('操作成功')
            ctx.emit('close')
            closeModal()
          })
          .catch((ex) => {
            console.log(ex)
            error('操作失败')
            closeModal()
          })
      }
      return { register, model: modelRef, handleOk }
    },
  })
</script>
